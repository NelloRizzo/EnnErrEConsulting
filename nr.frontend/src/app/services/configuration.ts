const BASE_URL = 'https:/localhost:7293/api'

const Configuration = {
    urls: {
        baseUrl: BASE_URL,
        login: `${BASE_URL}/Users/login`,
        registerUser: `${BASE_URL}/Users`
    }
}

export default Configuration