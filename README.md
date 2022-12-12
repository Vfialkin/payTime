# Pay Time!

![image](https://user-images.githubusercontent.com/1292458/206964928-11bd1a9e-0258-48de-8241-b068e209eda1.png)


## High level design:
- thin API layer with Swagger for API testing
- application services
- encapsulated Domain logic

### Some shortcuts to save time:
- no Infrastructure Layer: Hosting is merged with API and Repositories are in application layer
- no application models: domain models are leaked outside
- supports happy path scearios only, no model and buisness rules validations
- no configs, all values are hardcoded
- some other parts that I tried to annonate in the code
- no api annontations
- no tests
