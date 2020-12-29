# Architecture

It relies on k8s.

## Principles
- seamless deployment between releases
- how to persist Grafana setups/configurations between releases?
- how to deal with system configurations securely between releases?

## Api expectations
- it produces JSON
- it has its own Swagger
- Metrics are exposed
- it is authenticated/authorized
- it is stateless

## Services/containers
- Grafana container
- MasterData Database container
- MasterData Database storage container
- MasterData WebHost service/container

## Links
- https://youtu.be/sM7D8biBf4k
- https://youtu.be/YJgBAiPlG3k
- https://devblogs.microsoft.com/aspnet/observability-asp-net-core-apps/
