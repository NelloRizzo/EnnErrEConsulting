export interface LoginResponseModel {
    token: string
    username: string
    roles: string[]
}

export interface RegisterUserRequestModel {
    username: string,
    password: string,
    comparePassword: string,
    roles: string[]
}