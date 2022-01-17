# Dotify

## What is it?
The goal of this project is to document the iterative process of implementing and scaling an API -- building a monolithic structure, then refactoring to distributed microservices.

Since this project is focused on implementing an API, rather than designing one, we will be using the [Spotify Public API](https://developer.spotify.com/documentation/web-api/) as a reference for our functional requirements and data model.

## Overview
### Monolith
An application that is designed to run within a single process, on a single server, with a single database schema.

#### What We'll Use To Build It
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) (aka [Onion Architecture, Ports & Adapters, Hexagonal Architecture](https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)))
- ASP.NET Core Web API
- In-process messaging via [Mediatr](https://github.com/jbogard/MediatR)
- [MongoDB](https://docs.mongodb.com/)

### Microservices
blahblhablh

#### What We'll Use To Build It
- [MassTransit](https://masstransit-project.com/)
- [RabbitMQ](https://www.rabbitmq.com/)
- [Azure](https://docs.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net60&pivots=development-environment-vs)