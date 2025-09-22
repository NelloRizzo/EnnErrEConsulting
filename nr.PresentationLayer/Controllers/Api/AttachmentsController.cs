using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using nr.BusinessLayer.Dto.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Attachments;
using System.Net.Sockets;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController(IAttachmentService attachmentService, IFileProvider fileProvider, IMapper mapper) : ApiControllerBase
    {
        const string CREATED_AT_ROUTE_LINK = $"{nameof(AttachmentsController)}_{nameof(GetLink)}";
        const string CREATED_AT_ROUTE_ATTACHMENT = $"{nameof(AttachmentsController)}_{nameof(GetAttachment)}";

        /// <summary>
        /// Crea un content di tipo url tramite il quale poter recuperare un contenuto embedded.
        /// </summary>
        /// <param name="linkId">Id del contenuto.</param>
        /// <param name="mimeType">Tipo MIME del contenuto.</param>
        private UrlLinkModel UrlContent(int linkId, string mimeType) {
            //var url = Url.RouteUrl(CREATED_AT_ROUTE_LINK, new { linkId })!;
            var url = Url.RouteUrl(nameof(Download), new { linkId })!;
            return new() {
                MimeType = mimeType,
                Id = linkId,
                //Type = UrlLinkModel.ModelType,
                Url = url
            };
        }

        /// <summary>
        /// Upload di un contenuto.
        /// </summary>
        /// <param name="model">Dati di input da una richiesta MULTIPART/FORM-DATA.</param>
        [HttpPost("upload")]
        public async Task<AcceptedAtRoute> Upload([FromForm] ContentFileUploadModel model) {
            using var ms = new MemoryStream();
            await model.Content.CopyToAsync(ms);
            var attachment = new NewContentAttachmentModel {
                FileName = "file",
                Description = model.Description,
                Title = model.Title,
                Content = new ContentLinkModel {
                    //Content = Convert.ToBase64String(ms.ToArray()),
                    Content = [.. ms.ToArray().Select(b => (int)b)],
                    MimeType = model.Content.ContentType,
                    //Type = ContentLinkModel.ModelType
                }
            };
            var dto = mapper.Map<AttachmentDto>(attachment);
            var response = await attachmentService.AddAsync(dto);
            return TypedResults.AcceptedAtRoute(CREATED_AT_ROUTE_ATTACHMENT, new { attachmentId = response.Id });
        }
        /// <summary>
        /// Recupera un content di tipo url tramite il suo id.
        /// </summary>
        /// <param name="linkId">La chiave per il recupero.</param>
        [HttpGet("link/{linkId}", Name = CREATED_AT_ROUTE_LINK)]
        public async Task<Ok<LinkModel>> GetLink([FromRoute] int linkId) {
            var link = await attachmentService.GetLinkByAttachmentIdAsync(linkId);
            return TypedResults.Ok(mapper.Map<LinkModel>(link));
        }

        [HttpGet("download/{linkId}", Name = nameof(Download))]
        public async Task<IActionResult> Download([FromRoute] int linkId) {
            try {
                var attachment = await attachmentService.GetByIdAsync(linkId);
                var link = await attachmentService.GetLinkByAttachmentIdAsync(linkId);
                if (link is ContentLinkDto c) {
                    return File(c.Content, c.MimeType);
                }
                else {
                    using var http = new HttpClient();
                    return File(await http.GetByteArrayAsync(((UrlLinkDto)link).Url), link.MimeType);
                }
            }
            catch (Exception) {
                try {
                    var fileInfo = fileProvider.GetFileInfo("images/noimage.jpg");
                    return File(fileInfo.CreateReadStream(), "image/jpeg", "NoImageFound.jpg");
                }
                catch (Exception) {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Aggiunge un attachment con contenuto interno.
        /// </summary>
        /// <param name="model">Dati di input.</param>
        [HttpPost("internal")]
        public async Task<CreatedAtRoute<AttachmentModel>> AddInternal([FromBody] NewContentAttachmentModel model) {
            var dto = mapper.Map<AttachmentDto>(model);
            var response = await attachmentService.AddAsync(dto);
            var result = mapper.Map<AttachmentModel>(response);
            result.Content = UrlContent(response.ContentId, response.ContentType);
            return TypedResults.CreatedAtRoute(result, routeName: CREATED_AT_ROUTE_ATTACHMENT, routeValues: new { attachmentId = response.Id });
        }
        /// <summary>
        /// Aggiunge un attachment con contenuto interno.
        /// </summary>
        /// <param name="model">Dati di input.</param>
        [HttpPost("url")]
        public async Task<CreatedAtRoute<AttachmentModel>> AddUrl([FromBody] NewUrlAttachmentModel model) {
            var dto = mapper.Map<AttachmentDto>(model);
            var response = await attachmentService.AddAsync(dto);
            var result = mapper.Map<AttachmentModel>(response);
            result.Content = UrlContent(response.ContentId, response.ContentType);
            return TypedResults.CreatedAtRoute(result, routeName: CREATED_AT_ROUTE_ATTACHMENT, routeValues: new { attachmentId = response.Id });
        }
        /// <summary>
        /// Recupera un allegato.
        /// </summary>
        /// <param name="attachmentId">Chiave dell'allegato.</param>
        [HttpGet("{attachmentId}", Name = CREATED_AT_ROUTE_ATTACHMENT)]
        public async Task<Ok<AttachmentModel>> GetAttachment([FromRoute] int attachmentId) {
            var attachment = await attachmentService.GetByIdAsync(attachmentId);
            var model = mapper.Map<AttachmentModel>(attachment);
            model.Content = UrlContent(attachment.Id, attachment.ContentType);
            return TypedResults.Ok(model);
        }
        /// <summary>
        /// Recupera tutti gli allegati.
        /// </summary>
        [HttpGet]
        public async Task<Ok<IEnumerable<AttachmentModel>>> GetAllAttachments() {
            var attachment = await attachmentService.GetAllAsync();
            var result = new List<AttachmentModel>();
            foreach (var a in attachment) {
                var model = mapper.Map<AttachmentModel>(a);
                model.Content = UrlContent(a.Id, a.ContentType);
                result.Add(model);
            }
            return TypedResults.Ok<IEnumerable<AttachmentModel>>(result);
        }
    }
}
