# Cadmus Buondelmonti API

Quick Docker image build:

```bash
docker build . -t vedph2020/cadmus_bdm_api:4.0.0 -t vedph2020/cadmus_bdm_api:latest
docker push vedph2020/cadmus_bdm_api:4.0.0
```

(replace with the current version).

This is a Cadmus API layer customized for the Buondelmonti project. Most of its code is derived from shared Cadmus libraries. See the [documentation](https://github.com/vedph/cadmus_doc/blob/master/api/creating.md) for more.

## History

- 2023-05-10: updated packages.

### 4.0.0

- 2023-02-07: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.
- 2022-11-10: upgraded to NET 7.
- 2022-10-10: updated packages and injection in `Startup.cs` for new `IRepositoryProvider`.
- 2022-10-05:
  - updated packages and fixed references to legacy parts.
  - enabled preview.
- 2022-09-03: updated packages.
- 2022-07-27: updated packages.
- 2022-04-11: updated packages.

### 3.0.0

- 2021-12-21: updated packages.
- 2021-12-07 (v 3.0.0): upgraded to refactored Cadmus API components.
- 2021-11-11 (v 2.0.0): upgraded to NET 6.
- 2021-10-16 (v 1.1.0): breaking changes: for auth database by AspNetCore.Identity.Mongo 8.3.1 (used since Cadmus.Api.Controllers 1.3.0, Cadmus.Api.Services 1.2.0):

```js
/*
Removed fields:
AuthenticatorKey = null
RecoveryCodes = []
*/
db.Users.updateMany({}, { $unset: {"AuthenticatorKey": 1, "RecoveryCodes": 1} });
```

See <https://github.com/vedph/cadmus_tgr> for model-related changes.
