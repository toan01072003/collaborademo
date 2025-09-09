# Collabora Online + .NET 5 WOPI Host — Upload Starter (Railway)

## What you get
- Upload any Office/OpenDocument file
- Open in Collabora UI (View or Edit)
- Minimal WOPI endpoints: CheckFileInfo, GetFile, PutFile
- In-memory storage (ephemeral). For prod, swap to S3/MinIO.

## Deploy (Railway)
1. Create project → Deploy from Repo.
2. Two services via `Railway.toml`: `wopi-host` and `collabora`.
3. Set env vars:
   - **wopi-host**: `COLLABORA__BASEURL`, `APP__BASEURL`
   - **collabora**: `domain` (tight regex of wopi-host domain)
4. Open the wopi-host URL → upload → View/Edit.

## Local Dev
- Run Collabora locally on :9980, then `dotnet run` in `wopi-host`.
# collaborademo
