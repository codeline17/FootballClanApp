using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smaug.Bases;

namespace Smaug.Models
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class extended_fixtures
    {

        private extended_fixturesLeague[] leagueField;

        private string updatedField;

        private string sportField;

        private string countryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("league")]
        public extended_fixturesLeague[] league
        {
            get
            {
                return this.leagueField;
            }
            set
            {
                this.leagueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sport
        {
            get
            {
                return this.sportField;
            }
            set
            {
                this.sportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeague : BaseLeague
    {

        private extended_fixturesLeagueStage[] stageField;

        private extended_fixturesLeagueWeek[] weekField;

        private string nameField;

        private string seasonField;

        private ushort idField;

        private ushort sub_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("stage")]
        public extended_fixturesLeagueStage[] stage
        {
            get
            {
                return this.stageField;
            }
            set
            {
                this.stageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("week")]
        public extended_fixturesLeagueWeek[] week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string season
        {
            get
            {
                return this.seasonField;
            }
            set
            {
                this.seasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort sub_id
        {
            get
            {
                return this.sub_idField;
            }
            set
            {
                this.sub_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStage
    {

        private extended_fixturesLeagueStageAggregate[] aggregateField;

        private extended_fixturesLeagueStageMatch[] matchField;

        private extended_fixturesLeagueStageWeek[] weekField;

        private string nameField;

        private string roundField;

        private uint stage_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aggregate")]
        public extended_fixturesLeagueStageAggregate[] aggregate
        {
            get
            {
                return this.aggregateField;
            }
            set
            {
                this.aggregateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public extended_fixturesLeagueStageMatch[] match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("week")]
        public extended_fixturesLeagueStageWeek[] week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string round
        {
            get
            {
                return this.roundField;
            }
            set
            {
                this.roundField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint stage_id
        {
            get
            {
                return this.stage_idField;
            }
            set
            {
                this.stage_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageAggregate
    {

        private string firstteamField;

        private string scoreField;

        private string secondteamField;

        private byte winnerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string firstteam
        {
            get
            {
                return this.firstteamField;
            }
            set
            {
                this.firstteamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string secondteam
        {
            get
            {
                return this.secondteamField;
            }
            set
            {
                this.secondteamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte winner
        {
            get
            {
                return this.winnerField;
            }
            set
            {
                this.winnerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatch : BaseFixtures
    {

        private extended_fixturesLeagueStageMatchHome homeField;

        private extended_fixturesLeagueStageMatchHome awayField;

        private extended_fixturesLeagueStageMatchHalftime halftimeField;

        private extended_fixturesLeagueStageMatchGoal[] goalsField;

        private extended_fixturesLeagueStageMatchLineups lineupsField;

        private extended_fixturesLeagueStageMatchSubstitutions substitutionsField;

        private string alternate_idField;

        private uint alternate_id_2Field;

        private string dateField;

        private uint idField;

        private string static_idField;

        private string statusField;

        private string timeField;

        private string venueField;

        private string venue_cityField;

        private uint venue_idField;

        /// <remarks/>
        public extended_fixturesLeagueStageMatchHome home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageMatchHome away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageMatchHalftime halftime
        {
            get
            {
                return this.halftimeField;
            }
            set
            {
                this.halftimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("goal", IsNullable = false)]
        public extended_fixturesLeagueStageMatchGoal[] goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageMatchLineups lineups
        {
            get
            {
                return this.lineupsField;
            }
            set
            {
                this.lineupsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageMatchSubstitutions substitutions
        {
            get
            {
                return this.substitutionsField;
            }
            set
            {
                this.substitutionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string alternate_id
        {
            get
            {
                return this.alternate_idField;
            }
            set
            {
                this.alternate_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint alternate_id_2
        {
            get
            {
                return this.alternate_id_2Field;
            }
            set
            {
                this.alternate_id_2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string static_id
        {
            get
            {
                return this.static_idField;
            }
            set
            {
                this.static_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue
        {
            get
            {
                return this.venueField;
            }
            set
            {
                this.venueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue_city
        {
            get
            {
                return this.venue_cityField;
            }
            set
            {
                this.venue_cityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint venue_id
        {
            get
            {
                return this.venue_idField;
            }
            set
            {
                this.venue_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchHome : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchAway : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchHalftime
    {

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchGoal
    {

        private string assistField;

        private string minuteField;

        private string playerField;

        private uint playeridField;

        private string scoreField;

        private string teamField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string assist
        {
            get
            {
                return this.assistField;
            }
            set
            {
                this.assistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player
        {
            get
            {
                return this.playerField;
            }
            set
            {
                this.playerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint playerid
        {
            get
            {
                return this.playeridField;
            }
            set
            {
                this.playeridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchLineups
    {

        private extended_fixturesLeagueStageMatchLineupsPlayer[] homeField;

        private extended_fixturesLeagueStageMatchLineupsPlayer1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueStageMatchLineupsPlayer[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueStageMatchLineupsPlayer1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchLineupsPlayer
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchLineupsPlayer1
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchSubstitutions
    {

        private extended_fixturesLeagueStageMatchSubstitutionsSubstitution[] homeField;

        private extended_fixturesLeagueStageMatchSubstitutionsSubstitution1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueStageMatchSubstitutionsSubstitution[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueStageMatchSubstitutionsSubstitution1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchSubstitutionsSubstitution
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private byte player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchSubstitutionsSubstitution1
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private byte player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeek
    {

        private extended_fixturesLeagueStageWeekMatch[] matchField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public extended_fixturesLeagueStageWeekMatch[] match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatch
    {

        private extended_fixturesLeagueStageWeekMatchHome homeField;

        private extended_fixturesLeagueStageWeekMatchAway awayField;

        private extended_fixturesLeagueStageWeekMatchHalftime halftimeField;

        private extended_fixturesLeagueStageWeekMatchGoal[] goalsField;

        private extended_fixturesLeagueStageWeekMatchLineups lineupsField;

        private extended_fixturesLeagueStageWeekMatchSubstitutions substitutionsField;

        private string alternate_idField;

        private uint alternate_id_2Field;

        private string dateField;

        private uint idField;

        private string static_idField;

        private string statusField;

        private string timeField;

        private string venueField;

        private string venue_cityField;

        private uint venue_idField;

        /// <remarks/>
        public extended_fixturesLeagueStageWeekMatchHome home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageWeekMatchAway away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageWeekMatchHalftime halftime
        {
            get
            {
                return this.halftimeField;
            }
            set
            {
                this.halftimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("goal", IsNullable = false)]
        public extended_fixturesLeagueStageWeekMatchGoal[] goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageWeekMatchLineups lineups
        {
            get
            {
                return this.lineupsField;
            }
            set
            {
                this.lineupsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueStageWeekMatchSubstitutions substitutions
        {
            get
            {
                return this.substitutionsField;
            }
            set
            {
                this.substitutionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string alternate_id
        {
            get
            {
                return this.alternate_idField;
            }
            set
            {
                this.alternate_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint alternate_id_2
        {
            get
            {
                return this.alternate_id_2Field;
            }
            set
            {
                this.alternate_id_2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string static_id
        {
            get
            {
                return this.static_idField;
            }
            set
            {
                this.static_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue
        {
            get
            {
                return this.venueField;
            }
            set
            {
                this.venueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue_city
        {
            get
            {
                return this.venue_cityField;
            }
            set
            {
                this.venue_cityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint venue_id
        {
            get
            {
                return this.venue_idField;
            }
            set
            {
                this.venue_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchHome : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchAway : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchHalftime
    {

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchGoal
    {

        private string assistField;

        private string minuteField;

        private string playerField;

        private uint playeridField;

        private string scoreField;

        private string teamField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string assist
        {
            get
            {
                return this.assistField;
            }
            set
            {
                this.assistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player
        {
            get
            {
                return this.playerField;
            }
            set
            {
                this.playerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint playerid
        {
            get
            {
                return this.playeridField;
            }
            set
            {
                this.playeridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchLineups
    {

        private extended_fixturesLeagueStageWeekMatchLineupsPlayer[] homeField;

        private extended_fixturesLeagueStageWeekMatchLineupsPlayer1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueStageWeekMatchLineupsPlayer[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueStageWeekMatchLineupsPlayer1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchLineupsPlayer
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchLineupsPlayer1
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchSubstitutions
    {

        private extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution[] homeField;

        private extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private byte player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageWeekMatchSubstitutionsSubstitution1
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private byte player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeek
    {

        private extended_fixturesLeagueWeekMatch[] matchField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public extended_fixturesLeagueWeekMatch[] match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatch : BaseFixtures
    {

        private extended_fixturesLeagueWeekMatchHome homeField;

        private extended_fixturesLeagueWeekMatchAway awayField;

        private extended_fixturesLeagueWeekMatchHalftime halftimeField;

        private extended_fixturesLeagueWeekMatchGoal[] goalsField;

        private extended_fixturesLeagueWeekMatchLineups lineupsField;

        private extended_fixturesLeagueWeekMatchSubstitutions substitutionsField;

        private string alternate_idField;

        private uint alternate_id_2Field;

        private string dateField;

        private uint idField;

        private string static_idField;

        private string statusField;

        private string timeField;

        private string venueField;

        private string venue_cityField;

        private uint venue_idField;

        /// <remarks/>
        public extended_fixturesLeagueWeekMatchHome home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueWeekMatchAway away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueWeekMatchHalftime halftime
        {
            get
            {
                return this.halftimeField;
            }
            set
            {
                this.halftimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("goal", IsNullable = false)]
        public extended_fixturesLeagueWeekMatchGoal[] goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueWeekMatchLineups lineups
        {
            get
            {
                return this.lineupsField;
            }
            set
            {
                this.lineupsField = value;
            }
        }

        /// <remarks/>
        public extended_fixturesLeagueWeekMatchSubstitutions substitutions
        {
            get
            {
                return this.substitutionsField;
            }
            set
            {
                this.substitutionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string alternate_id
        {
            get
            {
                return this.alternate_idField;
            }
            set
            {
                this.alternate_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint alternate_id_2
        {
            get
            {
                return this.alternate_id_2Field;
            }
            set
            {
                this.alternate_id_2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string static_id
        {
            get
            {
                return this.static_idField;
            }
            set
            {
                this.static_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue
        {
            get
            {
                return this.venueField;
            }
            set
            {
                this.venueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string venue_city
        {
            get
            {
                return this.venue_cityField;
            }
            set
            {
                this.venue_cityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint venue_id
        {
            get
            {
                return this.venue_idField;
            }
            set
            {
                this.venue_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchHome : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchAway : BaseTeams
    {

        private string et_scoreField;

        private string ft_scoreField;

        private uint idField;

        private string nameField;

        private string pen_scoreField;

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string et_score
        {
            get
            {
                return this.et_scoreField;
            }
            set
            {
                this.et_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ft_score
        {
            get
            {
                return this.ft_scoreField;
            }
            set
            {
                this.ft_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pen_score
        {
            get
            {
                return this.pen_scoreField;
            }
            set
            {
                this.pen_scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchHalftime
    {

        private string scoreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchGoal
    {

        private string assistField;

        private string minuteField;

        private string playerField;

        private uint playeridField;

        private string scoreField;

        private string teamField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string assist
        {
            get
            {
                return this.assistField;
            }
            set
            {
                this.assistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player
        {
            get
            {
                return this.playerField;
            }
            set
            {
                this.playerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint playerid
        {
            get
            {
                return this.playeridField;
            }
            set
            {
                this.playeridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchLineups
    {

        private extended_fixturesLeagueWeekMatchLineupsPlayer[] homeField;

        private extended_fixturesLeagueWeekMatchLineupsPlayer1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueWeekMatchLineupsPlayer[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public extended_fixturesLeagueWeekMatchLineupsPlayer1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchLineupsPlayer
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private string numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchLineupsPlayer1
    {

        private string bookingField;

        private uint idField;

        private string nameField;

        private string numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchSubstitutions
    {

        private extended_fixturesLeagueWeekMatchSubstitutionsSubstitution[] homeField;

        private extended_fixturesLeagueWeekMatchSubstitutionsSubstitution1[] awayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueWeekMatchSubstitutionsSubstitution[] home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("substitution", IsNullable = false)]
        public extended_fixturesLeagueWeekMatchSubstitutionsSubstitution1[] away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchSubstitutionsSubstitution
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private string player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchSubstitutionsSubstitution1
    {

        private string minuteField;

        private string player_in_bookingField;

        private uint player_in_idField;

        private string player_in_nameField;

        private string player_in_numberField;

        private string player_out_idField;

        private string player_out_nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minute
        {
            get
            {
                return this.minuteField;
            }
            set
            {
                this.minuteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_booking
        {
            get
            {
                return this.player_in_bookingField;
            }
            set
            {
                this.player_in_bookingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint player_in_id
        {
            get
            {
                return this.player_in_idField;
            }
            set
            {
                this.player_in_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_name
        {
            get
            {
                return this.player_in_nameField;
            }
            set
            {
                this.player_in_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_in_number
        {
            get
            {
                return this.player_in_numberField;
            }
            set
            {
                this.player_in_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_id
        {
            get
            {
                return this.player_out_idField;
            }
            set
            {
                this.player_out_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string player_out_name
        {
            get
            {
                return this.player_out_nameField;
            }
            set
            {
                this.player_out_nameField = value;
            }
        }
    }


}
