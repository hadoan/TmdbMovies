const ENV = {
  dev: {
    apiUrl: 'http://localhost:44334',
    oAuthConfig: {
      issuer: 'http://localhost:44334',
      clientId: 'TmdbMovies_App',
      clientSecret: '1q2w3e*',
      scope: 'TmdbMovies',
    },
    localization: {
      defaultResourceName: 'TmdbMovies',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44334',
    oAuthConfig: {
      issuer: 'http://localhost:44334',
      clientId: 'TmdbMovies_App',
      clientSecret: '1q2w3e*',
      scope: 'TmdbMovies',
    },
    localization: {
      defaultResourceName: 'TmdbMovies',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
