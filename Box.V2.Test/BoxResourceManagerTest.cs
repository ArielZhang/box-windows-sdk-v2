﻿using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.Converter;
using Box.V2.Managers;
using Box.V2.Request;
using Box.V2.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.V2.Test
{
    public abstract class BoxResourceManagerTest 
    {

        protected IBoxConverter _converter;
        protected Mock<IRequestHandler> _handler;
        protected IBoxService _service;
        protected Mock<IBoxConfig> _config;
        protected AuthRepository _authRepository;

        protected Uri _baseUri = new Uri(Constants.BoxApiUriString);

        public BoxResourceManagerTest()
        {
            // Initial Setup
            _converter = new BoxJsonConverter();
            _handler = new Mock<IRequestHandler>();
            _service = new BoxService(_handler.Object);
            _config = new Mock<IBoxConfig>();

            _authRepository = new AuthRepository(_config.Object, _service, _converter, new OAuthSession("fakeAccessToken", "fakeRefreshToken", 3600, "bearer"));
        }
    }
}
