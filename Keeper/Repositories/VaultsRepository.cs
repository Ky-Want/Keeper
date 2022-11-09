namespace Keeper.Repositories;


public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }



  // NOTE: if this breaks it's line 21's fault
  internal Vault GetVaultById(int vaultId)
  {
    var sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE v.isPrivate = false
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


  public bool DeleteVault(int id)
  {
    return _db.Execute("DELETE FROM vaults WHERE id = @id", new { id }) == 1;
  }







  public Vault EditVault(Vault data)
  {
    var sql = @"
    UPDATE vaults SET
      name = @Name,
      isPrivate = @IsPrivate
    WHERE id = @id
    ;";

    int id = _db.ExecuteScalar<int>(sql, data);
    data.Id = id;
    return data;
  }
}