using System.Collections;
using System.Net.Http.Headers;
using Microsoft.UI.Xaml.Data;

namespace UnoApp5.Presentation
{
    public partial class GroupedListViewViewModel : ObservableObject
    {
        private INavigator _navigator;

        [ObservableProperty]
        private string? name;

        public Entity Entity { get; set; }

        public GroupedListViewViewModel(
            INavigator navigator,
            Entity entity)
        {
            Entity = entity;
            _navigator = navigator;

            GroupedTownsAsSource = GetAsCollectionViewSource(GetTownsGroupedAlphabetically());
        }

        private static IEnumerable<IGrouping<string, string>> GetTownsGroupedAlphabetically()
        {
            return Enumerable.Range(1, 2)
                .Select(x => new EmptyGroup<string, string>(x.ToString()))
                .Concat(
                    // left join
                    from letter in _alphabet
                    join g in SampleTowns.GroupBy(x => x.Substring(0, 1))
                        on letter equals g.Key into groupedTowns
                    select groupedTowns.FirstOrDefault() ?? new EmptyGroup<string, string>(letter)
                )
                .ToList();
        }

        internal static IEnumerable<object> GetAsCollectionViewSource<T1, T2>(IEnumerable<IGrouping<T1, T2>> groups)
        {
            var source = new CollectionViewSource()
            {
                Source = groups,
                IsSourceGrouped = true
            }.View;

            return source;
        }

        private class EmptyGroup<TKey, TValue> : IGrouping<TKey, TValue>
        {
            private TKey _key;

            public EmptyGroup(TKey key)
            {
                _key = key;
            }

            public TKey Key => _key;

            IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<object>().GetEnumerator();

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => Enumerable.Empty<TValue>().GetEnumerator();
        }

        public IEnumerable<object> GroupedTownsAsSource { get; set; }

        private static readonly string[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToArray();

        internal static readonly string[] SampleTowns =
        {
            "L'Île-Dorval",
            "Barkmere",
            "L'Île-Cadieux",
			//"Estérel",
			"Schefferville",
            "Lac-Saint-Joseph",
            "Belleterre",
            "Lac-Sergent",
            "Scotstown",
            "Lac-Delage",
            "Métis-sur-Mer",
            "Duparquet",
            "Murdochville",
            "Daveluyville",
            "Desbiens",
            "Matagami",
            "Chapais",
            "Fossambault-sur-le-Lac",
            "Saint-Joseph-de-Sorel",
            "Saint-Ours",
            "Kingsey Falls",
            "Waterville",
            "Lebel-sur-Quévillon",
            "Léry",
            "Valcourt",
            "Gracefield",
            "Témiscaming",
            "Thurso",
            "Huntingdon",
            "Causapscal",
            "Saint-Basile",
            "Disraeli",
            "Ville-Marie",
            "Cap-Chat",
            "Bedford",
            "Saint-Pamphile",
            "Macamic",
            "Sainte-Marguerite-du-Lac-Masson",
            "Pohénégamook",
            "Bonaventure",
            "Saint-Gabriel",
            "Sainte-Anne-de-Beaupré",
            "Stanstead",
            "Saint-Marc-des-Carrières",
            "Fermont",
            "Senneterre",
            "Cap-Santé",
            "Dégelis",
            "Portneuf",
            "Clermont",
            "Normandin",
            "Paspébiac",
            "Forestville",
            "Richmond",
            "Percé",
            "Beaupré",
            "Malartic",
            "Grande-Rivière",
            "Trois-Pistoles",
            "Dunham",
            "Saint-Pascal",
            "Montréal-Est",
			//"East Angus",
			"New Richmond",
            "Château-Richer",
            "Baie-D'Urfé",
            "Saint-Tite",
            "Neuville",
            "Sutton",
            "Maniwaki",
            "Carleton-sur-Mer",
            "Danville",
            "Berthierville",
            "Métabetchouan–Lac-à-la-Croix",
            "La Pocatière",
            "Waterloo",
            "Rivière-Rouge",
            "Saint-Joseph-de-Beauce",
            "Warwick",
            "Sainte-Anne-de-Bellevue",
            "Montreal West",
            "Témiscouata-sur-le-Lac",
            "Hudson",
            "Cookshire-Eaton",
            "L'Épiphanie",
            "Windsor",
            "Saint-Pie",
            "Richelieu",
            "Brome Lake",
            "Saint-Césaire",
            "Princeville",
            "Charlemagne",
            "Lac-Mégantic",
            "Contrecoeur",
            "Donnacona",
            "Sainte-Catherine-de-la-Jacques-Cartier",
            "Amqui",
            "Beauceville",
            "Port-Cartier",
            "Mont-Joli",
            "Plessisville",
            "Coteau-du-Lac",
            "Sainte-Anne-des-Monts",
            "Asbestos",
            "Hampstead",
            "Brownsburg-Chatham",
            "Saint-Rémi",
            "Baie-Saint-Paul",
            "Delson",
            "Louiseville",
            "Chibougamau",
            "Bromont",
            "Acton Vale",
            "Chandler",
            "La Sarre",
            "Nicolet",
            "Carignan",
            "Farnham",
			//"Otterburn Park",
			"Pont-Rouge",
            "La Malbaie",
            "Notre-Dame-des-Prairies",
            "Coaticook",
            "Lorraine",
            "Bois-des-Filion",
            "Mont-Tremblant",
            "Saint-Raymond",
            "Saint-Sauveur",
            "Marieville",
            "Sainte-Agathe-des-Monts",
            "Roberval",
            "Saint-Félicien",
            "L'Île-Perrot",
            "Notre-Dame-de-l'Île-Perrot",
            "La Tuque",
            "Montmagny",
            "Mercier",
            "Beauharnois",
            "Sainte-Adèle",
            "Prévost",
            "Bécancour",
            "Cowansville",
            "Lachute",
            "Amos",
            "Sainte-Marie",
            "Saint-Colomban",
            "Lavaltrie",
            "Mont-Laurier",
            "Rosemère",
            "Pincourt",
            "Dolbeau-Mistassini",
            "Matane",
            "Sainte-Anne-des-Plaines",
            "Gaspé",
            "Sainte-Marthe-sur-le-Lac",
            "Saint-Basile-le-Grand",
            "L'Ancienne-Lorette",
            "Sainte-Catherine",
            "Saint-Lin-Laurentides",
            "Deux-Montagnes",
            "Saint-Augustin-de-Desmaures",
            "Mont-Saint-Hilaire",
            "Dorval",
            "Saint-Lazare",
            "Rivière-du-Loup",
            "Mount Royal",
            "Beaconsfield",
            "Joliette",
            "Candiac",
            "Westmount",
            "L'Assomption",
            "Beloeil",
            "Varennes",
            "Kirkland",
            "Saint-Lambert",
            "Baie-Comeau",
            "La Prairie",
            "Saint-Constant",
            "Magog",
            "Chambly",
            "Sept-Îles",
            "Thetford Mines",
            "Sainte-Thérèse",
            "Saint-Bruno-de-Montarville",
            "Boisbriand",
            "Sainte-Julie",
            "Pointe-Claire",
            "Alma",
            "Saint-Georges",
            "Val-d'Or",
            "Côte Saint-Luc",
            "Vaudreuil-Dorion",
            "Sorel-Tracy",
            "Salaberry-de-Valleyfield",
            "Boucherville",
            "Rouyn-Noranda",
            "Mirabel",
            "Mascouche",
            "Victoriaville",
            "Saint-Eustache",
            "Châteauguay",
            "Rimouski",
            "Dollard-des-Ormeaux",
            "Shawinigan",
            "Saint-Hyacinthe",
            "Blainville",
            "Granby",
            "Saint-Jérôme",
            "Drummondville",
            "Brossard",
            "Repentigny",
            "Saint-Jean-sur-Richelieu",
            "Terrebonne",
            "Trois-Rivières",
            "Lévis",
            "Saguenay",
            "Sherbrooke",
            "Longueuil",
            "Gatineau",
            "Laval",
            "Québec",
            "Montreal",
        };

    }
}