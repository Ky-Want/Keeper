namespace Keeper.Repositories;


public class KeepsRepository : BaseRepository
{
  internal List<Keep> GetKeepsByVaultId(int vaultId)
  {
    var sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON a.id = k.creatorId
    WHERE k.keepId = @keepId
    ;";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { vaultId }).ToList();
  }


  internal List<Keep> GetKeeps()
  {
    // var sql = @"
    // SELECT
    // c.*,
    //   COUNT(cm.id) AS MemberCount,
    // a.*
    // FROM cults c
    //   JOIN accounts a ON a.id = c.leaderId
    //   LEFT JOIN cult_members cm ON cm.cultId = c.id
    // GROUP BY c.id
    // ;";

    // return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    // {
    //   keep.Creator = profile;
    //   return keep;
    // }).ToList();

    var sql = @"
      SELECT * FROM keepsDTO
    ;";
    return _db.Query<Keep>(sql).ToList();
  }







  internal Keep CreateKeep(Keep newKeep)
  {
    var sql = @"
      INSERT INTO keeps(
    img, 
    name, 
    description, 
    creatorId, 
    views, 
    kept
    )
      VALUES(
    @Img, 
    @Name, 
    @Description, 
    @CreatorId, 
    @Views, 
    @Kept
    );
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, newKeep);
    newKeep.Id = id;
    return newKeep;
  }







  public KeepsRepository(IDbConnection db) : base(db) { }
}