# Pay Time!

## High level design:
- Thin API layer with Swagger for API testing
- Application services
- Encapsulated Domain logic

### Some shortcuts to save time:
- no Infrastructure Layer: Hosting is merged with API and Repositories are in application layer
- no application models: domain models are leaked outside
- supports happy path scearios only, no model and buisness rules validations
- no configs, all values are hardcoded
- some other parts that tried to annonate in the code
- no api annontations
- no tests
