namespace Keeper.Repositories;


// NOTE: left join adds everything in, 
// NOTE: inner join gets rid of duplicate data


public class KeepsRepository : BaseRepository
{
  internal List<Keep> GetKeeps()
  {
    var sql = @"
      SELECT 
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
        GROUP BY (k.id)
    ;";
    return _db.Query<Keep, Profile, Keep>(sql, (ke, p) =>
    {
      ke.Creator = p;
      return ke;
    }).ToList();
  }


  internal Keep GetKeepById(int id)
  {
    var sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON a.id = k.creatorId
    WHERE k.id = @id
      GROUP BY k.id
    ;";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, p) =>
    {
      keep.Creator = p;
      return keep;
    }, new { id }).FirstOrDefault();
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


  public void DeleteKeep(int id)
  {
    _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
  }







  internal Keep EditKeep(Keep data)
  {
    // img = @Img,
    var sql = @"
    UPDATE keeps SET
      name = @Name,
      description = @Description,
      kept = @Kept,
      views = @Views
    WHERE id = @id
    ;";

    data.UpdatedAt = DateTime.Now;
    _db.Execute(sql, data);

    return data;
  }




  public KeepsRepository(IDbConnection db) : base(db) { }
}