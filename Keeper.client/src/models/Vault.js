export class Vault {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.creator = data.creator

    this.name = data.name
    this.img = data.img
    this.description = data.description
    this.isPrivate = data.isPrivate
  }
}