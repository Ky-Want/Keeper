export class Keep {
  constructor(data) {
    this.id = data.id
    this.vaultId = data.vaultId
    this.creatorId = data.creatorId
    this.vaultKeepId = data.vaultKeepId

    this.creator = data.creator

    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt

    this.img = data.img
    this.name = data.name
    this.description = data.description
    this.views = data.views
    this.kept = data.kept
  }
}