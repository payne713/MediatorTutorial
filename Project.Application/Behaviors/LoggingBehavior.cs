﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Initizalize

        /// <summary>
        /// logger
        /// </summary>
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion Initizalize

        #region Handlers

        /// <summary>
        /// logging command info
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling command {CommandName} ({@Command})", typeof(TRequest).Name, request);
            var response = await next();
            _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", typeof(TResponse).Name, response);

            return response;
        }

        #endregion Handlers
    }
}