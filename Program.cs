using System;

namespace ChampionFactoryExample
{

    public interface IRole
    {
        string GetDescription();
    }

    public interface IRegion
    {
        string GetDescription();
    }

    public interface IHeroes
    {
        string GetDescription();
    }

    public interface IChampionFactory
    {
        IRegion CreateRegion();
        IHeroes CreateHeroes();
        IRole CreateRole();
    }


    public class IoniaRole : IRole
    {
        private const string DESCRIPTION = "Ionia – mistrz sztuk walki i równowagi";

        public string GetDescription() => DESCRIPTION;
    }

    public class NoxusRole : IRole
    {
        private const string DESCRIPTION = "Noxus – siła i bezwzględność";

        public string GetDescription() => DESCRIPTION;
    }



    public class IoniaRegion : IRegion
    {
        private const string DESCRIPTION = "Region Ionia – mistyczna kraina duchów";

        public string GetDescription() => DESCRIPTION;
    }

    public class NoxusRegion : IRegion
    {
        private const string DESCRIPTION = "Region Noxus – kraina okrucieństwa i siły";

        public string GetDescription() => DESCRIPTION;
    }



    public class IoniaHeroes : IHeroes
    {
        private const string DESCRIPTION = "Drużyna Ionia: Yasuo, Karma, Zed";

        public string GetDescription() => DESCRIPTION;
    }

    public class NoxusHeroes : IHeroes
    {
        private const string DESCRIPTION = "Drużyna Noxus: Darius, Katarina, Swain";

        public string GetDescription() => DESCRIPTION;
    }


    public class IoniaChampionFactory : IChampionFactory
    {
        public IRegion CreateRegion() => new IoniaRegion();
        public IHeroes CreateHeroes() => new IoniaHeroes();
        public IRole CreateRole() => new IoniaRole();
    }

    public class NoxusChampionFactory : IChampionFactory
    {
        public IRegion CreateRegion() => new NoxusRegion();
        public IHeroes CreateHeroes() => new NoxusHeroes();
        public IRole CreateRole() => new NoxusRole();
    }



    public class App
    {
        private IRegion _region;
        private IHeroes _heroes;
        private IRole _role;

        public void SetRegion(IRegion region) => _region = region;
        public void SetHeroes(IHeroes heroes) => _heroes = heroes;
        public void SetRole(IRole role) => _role = role;

        public IRegion GetRegion(IChampionFactory factory) => factory.CreateRegion();
        public IHeroes GetHeroes(IChampionFactory factory) => factory.CreateHeroes();
        public IRole GetRole(IChampionFactory factory) => factory.CreateRole();

        public void CreateChampion(IChampionFactory factory)
        {
 
            _region = factory.CreateRegion();
            _heroes = factory.CreateHeroes();
            _role = factory.CreateRole();


            Console.WriteLine(_region.GetDescription());
            Console.WriteLine(_heroes.GetDescription());
            Console.WriteLine(_role.GetDescription());
        }

        public static void Main(string[] args)
        {
            var app = new App();

            Console.WriteLine("=== Ionia Champion ===");
            IChampionFactory ioniaFactory = new IoniaChampionFactory();
            app.CreateChampion(ioniaFactory);

            Console.WriteLine("\n=== Noxus Champion ===");
            IChampionFactory noxusFactory = new NoxusChampionFactory();
            app.CreateChampion(noxusFactory);


            Console.WriteLine("\nPobranie pojedynczych elementów z fabryki:");
            Console.WriteLine("Region: " + app.GetRegion(noxusFactory).GetDescription());
            Console.WriteLine("Heroes: " + app.GetHeroes(ioniaFactory).GetDescription());
            Console.WriteLine("Role: " + app.GetRole(ioniaFactory).GetDescription());
        }
    }
}
