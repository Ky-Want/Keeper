namespace Keeper.Repositories;


public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }




  // internal List<Keep> GetKeepsByVaultId(int vaultId)
  // {
  //   var sql = @"
  //   SELECT
  //   k.*,
  //   a.*
  //   FROM keeps k
  //   JOIN accounts a ON a.id = k.creatorId
  //   WHERE k.keepId = @keepId
  //   ;";

  //   return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
  //   {
  //     keep.CreatorId = profile;
  //     return keep;
  //   }, new { vaultId }).ToList();
  // }
}