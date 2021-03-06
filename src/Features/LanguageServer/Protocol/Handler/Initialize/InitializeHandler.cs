﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.LanguageServer.Protocol;

namespace Microsoft.CodeAnalysis.LanguageServer.Handler
{
    [Shared]
    [ExportLspMethod(Methods.InitializeName)]
    internal class InitializeHandler : IRequestHandler<InitializeParams, InitializeResult>
    {
        private static readonly InitializeResult s_initializeResult = new InitializeResult
        {
            Capabilities = new ServerCapabilities
            {
                DefinitionProvider = true,
                ImplementationProvider = true,
                CompletionProvider = new CompletionOptions { ResolveProvider = true, TriggerCharacters = new[] { "." } },
                SignatureHelpProvider = new SignatureHelpOptions { TriggerCharacters = new[] { "(", "," } },
                DocumentSymbolProvider = true,
                WorkspaceSymbolProvider = true,
                DocumentFormattingProvider = true,
                DocumentRangeFormattingProvider = true,
                DocumentOnTypeFormattingProvider = new DocumentOnTypeFormattingOptions { FirstTriggerCharacter = "}", MoreTriggerCharacter = new[] { ";", "\n" } },
                DocumentHighlightProvider = true,
            }
        };

        public Task<InitializeResult> HandleRequestAsync(Solution solution, InitializeParams request, ClientCapabilities clientCapabilities, CancellationToken cancellationToken)
            => Task.FromResult(s_initializeResult);
    }
}
