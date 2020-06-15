export const environment = {
  production: true,
  application: {
    name: 'TmdbMovies',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44334',
    clientId: 'TmdbMovies_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'TmdbMovies',
    showDebugInformation: true,
    oidc: false,
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:44334',
    },
  },
  localization: {
    defaultResourceName: 'TmdbMovies',
  },
};
