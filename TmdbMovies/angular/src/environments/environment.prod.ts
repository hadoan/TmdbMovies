export const environment = {
  production: true,
  application: {
    name: 'TmdbMovies',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://52.163.221.126',
    clientId: 'TmdbMovies_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'TmdbMovies',
    showDebugInformation: true,
    oidc: false,
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'http://52.163.221.126',
    },
  },
  localization: {
    defaultResourceName: 'TmdbMovies',
  },
};
