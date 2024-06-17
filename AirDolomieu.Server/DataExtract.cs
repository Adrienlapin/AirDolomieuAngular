using AirDolomieu.Server;
using System.Collections.ObjectModel;

namespace AirDolomieu.Server
{
    public class DataExtract
    {

        public DataExtract()
        {
            AirDolomieuContext _context = new AirDolomieuContext();
        }

        //return all table ViewVols
        public List<ViewVol> GetAllViewVols()
        {
            List<ViewVol> list = new List<ViewVol>();
            

            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                list = _context.ViewVols.ToList();
            }
            
            return list;
        }


        //Return list vol for Pilote selected
        public List<ViewVol> GetViewVolsbyPilote(int P)
        {
            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
                    from vol in _context.Vols
                    where vol.NumpiloteNavigation.Numpilote == P
                    select new ViewVol
                    {
                        Numvol = vol.Numvol,
                        Nompilote = vol.NumpiloteNavigation.Nompilote.Trim(),
                        Nomavion = vol.NumavionNavigation.Nomavion.Trim() + "-" + vol.NumavionNavigation.Numavion.ToString(),
                        Heuredep = vol.Heuredep,
                        Villedep = vol.Villedep,
                        Heurearr = vol.Heurearr,
                        Villearr = vol.Villearr
                    };

                return query.ToList();
            }
        }

        //Return List Vol for all plane selected
        public List<ViewVol> GetViewVolsbyAvion(int A)
        {
            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
                from vol in _context.Vols
                where vol.NumavionNavigation.Numavion == A
                select new ViewVol
                {
                    Numvol = vol.Numvol,
                    Nompilote = vol.NumpiloteNavigation.Nompilote.Trim(),
                    Nomavion = vol.NumavionNavigation.Nomavion.Trim() + "-" + vol.NumavionNavigation.Numavion.ToString(),
                    Heuredep = vol.Heuredep,
                    Villedep = vol.Villedep,
                    Heurearr = vol.Heurearr,
                    Villearr = vol.Villearr
                };
                return query.ToList();
            }
        }

        //Return List Vol with plane and pilote selected
        public List<ViewVol> GetViewVolsbyAll(int P, int A)
        {
            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
                from vol in _context.Vols
                where vol.NumpiloteNavigation.Numpilote == P && vol.NumavionNavigation.Numavion == A
                select new ViewVol
                {
                    Numvol = vol.Numvol,
                    Nompilote = vol.NumpiloteNavigation.Nompilote.Trim(),
                    Nomavion = vol.NumavionNavigation.Nomavion.Trim() + "-" + vol.NumavionNavigation.Numavion.ToString(),
                    Heuredep = vol.Heuredep,
                    Villedep = vol.Villedep,
                    Heurearr = vol.Heurearr,
                    Villearr = vol.Villearr
                };
                return query.ToList();
            }
        }

        //return all table Pilote
        public List<Pilote> GetAllPilote()
        {
            List<Pilote> list = new List<Pilote>();

            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
                from pilote in _context.Pilotes
                select new Pilote
                {
                    Numpilote = pilote.Numpilote,
                    Adresse = pilote.Adresse,
                    Nompilote = pilote.Nompilote.Trim()
                };
                return query.ToList();
            }
        }

        //return all table Avion
        public List<Avion> GetAllAvion()
        {
            List<Avion> list = new List<Avion>();

            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
              from avion in _context.Avions
              select new Avion
              {
                  Numavion = avion.Numavion,
                  Nomavion = avion.Nomavion.Trim() + "-" + avion.Numavion.ToString(),
                  Capacite = avion.Capacite,
                  Localisation = avion.Localisation
              };
                return query.ToList();
            }
        }

        public Vol GetOneVol(String Numvol)
        {
            using (AirDolomieuContext _context = new AirDolomieuContext())
            {
                var query =
                from vol in _context.Vols
                where vol.Numvol == Numvol
                select new Vol
                {
                    Numvol = vol.Numvol,
                    Numavion = vol.Numavion,
                    Numpilote = vol.Numpilote,
                    Heuredep = vol.Heuredep,
                    Villedep = vol.Villedep,
                    Heurearr = vol.Heurearr,
                    Villearr = vol.Villearr
                };
                if (query.ToList().Count == 0)
                {
                    return null;
                }
                else
                {
                    return query.ToList()[0];
                }
            }
        }

        //Ajouter un vol avec EntityFramework
        public String PutNewVol(Vol fly)
        {
            String message = String.Empty;
            try
            {
                
                using (AirDolomieuContext _context = new AirDolomieuContext())
                {
                    _context.Vols.Add(fly);
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                message = ex.Message + "\n" + ex.StackTrace.ToString();
                return message;
            }
            message = "OK";
            return message;

        }




    }
}
