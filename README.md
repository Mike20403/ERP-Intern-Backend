# DotNetStarter

## Develop instruction

Please clone `appsettings.Development.example.json`  to `appsettings.Development.json` for local using only

**Default user:** `admin.dotnetstarter@yopmail.com`/`Abc!2345`

## Deployment

- Install docker at https://docs.docker.com/get-docker/

```bash
# docker login
$ docker login --username xxx --password xxx

# dev
$ docker compose build
$ docker tag eztekdockerhub.azurecr.io/dot-net-starter:latest eztekdockerhub.azurecr.io/dot-net-starter:latest
$ docker push eztekdockerhub.azurecr.io/dot-net-starter:latest
```

- Access to server, run:

```bash
# dev
$ docker stop dot-net-starter
$ docker compose pull
$ docker compose up -d
```
