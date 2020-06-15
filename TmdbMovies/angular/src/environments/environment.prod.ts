export const environment = {
  production: true,
  application: {
    name: 'TmdbMovies',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://13.76.225.37/api',
    clientId: 'TmdbMovies_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'TmdbMovies',
    showDebugInformation: true,
    oidc: false,
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'http://13.76.225.37/api',
    },
  },
  localization: {
    defaultResourceName: 'TmdbMovies',
  },
};
