# Enterprise AI Knowledge Assistant

A .NET 8 portfolio project for building an enterprise document question-answering platform using Retrieval-Augmented Generation (RAG).

## Current Status

Phase 1: Repository scaffold and basic ASP.NET Core API.

## Planned Features

- Document upload and indexing
- PDF, DOCX, and TXT ingestion
- Text chunking and vector embeddings
- Azure OpenAI integration
- Azure AI Search integration
- Chat with citations
- JWT authentication and role-based authorization
- Conversation history
- Docker support
- Automated tests and CI/CD

## Solution Structure

```text
src/
  KnowledgeAssistant.Api/
  KnowledgeAssistant.Application/
  KnowledgeAssistant.Domain/
  KnowledgeAssistant.Infrastructure/
tests/
  KnowledgeAssistant.UnitTests/
docs/
```

## Run Locally

Requirements: .NET 8 SDK

```bash
dotnet restore
dotnet build
dotnet run --project src/KnowledgeAssistant.Api
```

Open Swagger at `https://localhost:7001/swagger`.

## Initial Endpoint

`GET /api/health`

## Roadmap

1. Repository scaffold
2. Domain and application models
3. Document upload
4. Local text extraction
5. Azure Blob Storage
6. Azure AI Search
7. Azure OpenAI and RAG
8. Authentication
9. Docker and CI/CD
10. Production deployment

## Disclaimer

This is an independent learning and portfolio project. Cloud integrations will be added incrementally.
