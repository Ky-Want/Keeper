namespace Keeper.Repositories;


public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }




  internal Vault GetVaultById(int vaultId)
  {
    var sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE v.id = @vaultId
    ;";

    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
  }







  internal Vault CreateVault(Vault newVault)
  {
    var sql = @"
    INSERT INTO vaults(
      name,
      creatorId, 
      description, 
      isPrivate, 
      img)
    VALUES(
      @Name, 
      @CreatorId,
      @Description, 
      @IsPrivate, 
      @Img);
    SELECT LAST_INSERT_ID()
    ;";

    int newVaultId = _db.ExecuteScalar<int>(sql, newVault);
    newVault.Id = newVaultId;
    return newVault;
  }


  // FIXME: failing both tests
  public bool DeleteVault(int id)
  {
    return _db.Execute("DELETE FROM vaults WHERE id = @id", new { id }) == 1;
  }







  // edit
}