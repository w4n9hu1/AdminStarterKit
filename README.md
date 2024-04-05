# AdminStarterKit

## AdminStarterKit.Api/Application

Application layer that implements the use cases of the application based on the domain.

### Contracts

A thin project that contains the application service interfaces and the DTOs used by these interfaces. This project can be shared by the client applications (including the UI).

### Object To Object Mapping

- Use auto object mapping only for Entity to output DTO mappings.
- Do not use auto object mapping for input DTO to Entity mappings.

### Application Service

An Application Service is a stateless service that implements use cases of the application.
An application service typically gets and returns DTOs.It is used by the Presentation Layer.
It uses and coordinates the domain objects to implement the use cases. A use case is typically considered as a Unit Of Work.

### Data Transfer Object (DTO)

A DTO is a simple object without any business logic that is used to transfer state (data) between the Application and Presentation Layers.

### Unit of Work (UOW)

A Unit of Work is an atomic work that should be done as a transaction unit. All the operations inside a UOW should be committed on success or rolled back on a failure.

## AdminStarterKit.Domain

Domain layer that contains all the building blocks (entities, value objects, domain services, specifications, repository interfaces, etc.)

### Shared

A thin project that contains some types those belong to the Domain Layer, but shared with all other layers. 
For example, it may contain some constants and enums related to the Domain Objects but need to be reused by other layers.

### Entity

An Entity is an object with its own properties
(state, data) and methods that implements the business
logic that is executed on these properties. An entity is
represented by its unique identifier (Id). Two entity object
with different Ids are considered as different entities.

### Value Object

A Value Object is another kind of domain
object that is identified by its properties rather than a
unique Id. That means two Value Objects with same
properties are considered as the same object. Value
objects are generally implemented as immutable and
mostly are much simpler than the Entities.

###  Aggregate & Aggregate Root

An Aggregate is a cluster
of objects (entities and value objects) bound together by
an Aggregate Root object. The Aggregate Root is a
specific type of an entity with some additional
responsibilities.

### Repository (interface)

A Repository is a collection-like
interface that is used by the Domain and Application
Layers to access to the data persistence system (the
database). It hides the complexity of the DBMS from the
business code. Domain Layer contains the interfaces of the
repositories.

### Domain Service

A Domain Service is a stateless service
that implements core business rules of the domain. It is
useful to implement domain logic that depends on
multiple aggregate (entity) type or some external
services.

### Specification

A Specification is used to define named,
reusable and combinable filters for entities and other
business objects.

### Domain Event

A Domain Event is a way of informing
other services in a loosely coupled manner, when a
domain specific event occurs.

- Local Event Bus is suitable for in-process messaging.
- Distributed Event Bus is suitable for inter-process messaging, like microservices publishing and subscribing to distributed events.

## AdminStarterKit.Infrastructure