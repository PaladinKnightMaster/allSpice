export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false
export const domain = 'tm-auth-domain.us.auth0.com'
export const clientId = 'CNvzl82tfeZslCJFu1uYKnVosdlR56rB'
export const audience = 'https://bcw-work.com'
