using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Attachments;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Attachments;
using System.Net.Mime;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController(IAttachmentService attachmentService, IMapper mapper, ILogger<AttachmentsController> logger) : ApiControllerBase
    {
        const string CREATED_AT_ROUTE_LINK = $"{nameof(AttachmentsController)}_{nameof(GetLink)}";
        const string CREATED_AT_ROUTE_ATTACHMENT = $"{nameof(AttachmentsController)}_{nameof(GetAttachment)}";

        private UrlLinkModel UrlContent(int linkId, string mimeType) {
            var url = Url.RouteUrl(CREATED_AT_ROUTE_LINK, new { linkId })!;
            return new() {
                MimeType = mimeType,
                Id = linkId,
                Type = UrlLinkModel.ModelType,
                Url = url
            };
        }

        [HttpPost("Upload")]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(typeof(AttachmentModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        public async Task<Results<CreatedAtRoute<AttachmentModel>, BadRequest<string>, InternalServerError>> Upload([FromForm] ContentFileUploadModel model) {
            if (ModelState.IsValid) {
                try {
                    using var ms = new MemoryStream();
                    await model.Content.CopyToAsync(ms);
                    var attachment = new NewAttachmentModel {
                        Description = model.Description,
                        Title = model.Title,
                        Content = new ContentLinkModel {
                            Content = Convert.ToBase64String(ms.ToArray()),
                            MimeType = model.Content.ContentType,
                            Type = ContentLinkModel.ModelType
                        }
                    };
                    var dto = mapper.Map<AttachmentDto>(attachment);
                    var response = await attachmentService.AddAsync(dto);

                    var responseModel = mapper.Map<AttachmentModel>(response);

                    responseModel.Content = UrlContent(response.Id, dto.Content.MimeType);

                    return TypedResults.CreatedAtRoute(responseModel, CREATED_AT_ROUTE_ATTACHMENT, responseModel.Id);
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding attachment");
                    return TypedResults.InternalServerError();
                }
            }
            return TypedResults.BadRequest("Invalid model");
        }

        [HttpGet("link/{linkId}", Name = CREATED_AT_ROUTE_LINK)]
        [ProducesResponseType(typeof(LinkModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<LinkModel>, InternalServerError>> GetLink([FromRoute] int linkId) {
            try {
                var link = await attachmentService.GetLinkByIdAsync(linkId);
                return TypedResults.Ok(mapper.Map<LinkModel>(link));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting link {}", linkId);
                return TypedResults.InternalServerError();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(AttachmentModel), StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        public async Task<Results<CreatedAtRoute<AttachmentModel>, BadRequest<string>, InternalServerError>> Add([FromBody] NewAttachmentModel model) {
            if (ModelState.IsValid) {
                try {
                    var dto = mapper.Map<AttachmentDto>(model);
                    var response = await attachmentService.AddAsync(dto);
                    var result = mapper.Map<AttachmentModel>(response);
                    result.Content = UrlContent(response.ContentId, response.ContentType);
                    return TypedResults.CreatedAtRoute(result, CREATED_AT_ROUTE_ATTACHMENT, new { attachmentId = response.Id });
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding attachment");
                    return TypedResults.InternalServerError();
                }
            }
            return TypedResults.BadRequest("Invalid model");
        }

        [HttpGet("{attachmentId}", Name = CREATED_AT_ROUTE_ATTACHMENT)]
        [ProducesResponseType(typeof(AttachmentModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<AttachmentModel>, InternalServerError>> GetAttachment([FromRoute] int attachmentId) {
            try {
                var attachment = await attachmentService.GetByIdAsync(attachmentId);
                var model = mapper.Map<AttachmentModel>(attachment);
                model.Content = UrlContent(attachment.Id, attachment.ContentType);
                return TypedResults.Ok(model);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting attachment {}", attachmentId);
                return TypedResults.InternalServerError();
            }
        }
    }
}
