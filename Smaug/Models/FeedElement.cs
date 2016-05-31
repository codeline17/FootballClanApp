using Smaug.Bases;
using System;

namespace Smaug.Models
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeague : BaseLeague
    {
        private extended_fixturesLeagueWeek[] weekField;
        private extended_fixturesLeagueStage[] stageField;
        private string nameField;
        private string seasonField;
        private long idField;
        private bool idFieldSpecified;
        private long sub_idField;
        private bool sub_idFieldSpecified;
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public long id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public long sub_id
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
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sub_idSpecified
        {
            get
            {
                return this.sub_idFieldSpecified;
            }
            set
            {
                this.sub_idFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeek
    {
        private extended_fixturesLeagueWeekMatch[] matchField;
        private sbyte numberField;
        private bool numberFieldSpecified;
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
        [System.Xml.Serialization.XmlAttribute()]
        public sbyte number
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
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberSpecified
        {
            get
            {
                return this.numberFieldSpecified;
            }
            set
            {
                this.numberFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatch
    {
        private extended_fixturesLeagueWeekMatchHome homeField;
        private extended_fixturesLeagueWeekMatchAway awayField;
        private extended_fixturesLeagueWeekMatchHalftime halftimeField;
        private string goalsField;
        private string lineupsField;
        private string substitutionsField;
        private string alternate_idField;
        private int alternate_id_2Field;
        private bool alternate_id_2FieldSpecified;
        private string dateField;
        private int idField;
        private bool idFieldSpecified;
        private string static_idField;
        private string statusField;
        private string timeField;
        private string venueField;
        private string venue_cityField;
        private int venue_idField;
        private bool venue_idFieldSpecified;
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
        public string goals
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
        public string lineups
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
        public string substitutions
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int alternate_id_2
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool alternate_id_2Specified
        {
            get
            {
                return this.alternate_id_2FieldSpecified;
            }
            set
            {
                this.alternate_id_2FieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int venue_id
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
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool venue_idSpecified
        {
            get
            {
                return this.venue_idFieldSpecified;
            }
            set
            {
                this.venue_idFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchHome : BaseTeams
    {
        private string et_scoreField;
        private string ft_scoreField;
        private int idField;
        private bool idFieldSpecified;
        private string nameField;
        private string pen_scoreField;
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchAway : BaseTeams
    {
        private string et_scoreField;
        private string ft_scoreField;
        private int idField;
        private bool idFieldSpecified;
        private string nameField;
        private string pen_scoreField;
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueWeekMatchHalftime
    {
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStage
    {
        private extended_fixturesLeagueStageMatch[] matchField;
        private string[] textField;
        private string nameField;
        private string roundField;
        private long stage_idField;
        private bool stage_idFieldSpecified;
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public long stage_id
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
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool stage_idSpecified
        {
            get
            {
                return this.stage_idFieldSpecified;
            }
            set
            {
                this.stage_idFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatch
    {
        private extended_fixturesLeagueStageMatchHome homeField;
        private extended_fixturesLeagueStageMatchAway awayField;
        private extended_fixturesLeagueStageMatchHalftime halftimeField;
        private string goalsField;
        private string lineupsField;
        private string substitutionsField;
        private string alternate_idField;
        private int alternate_id_2Field;
        private bool alternate_id_2FieldSpecified;
        private string dateField;
        private int idField;
        private bool idFieldSpecified;
        private string static_idField;
        private string statusField;
        private string timeField;
        private string venueField;
        private string venue_cityField;
        private int venue_idField;
        private bool venue_idFieldSpecified;
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
        public extended_fixturesLeagueStageMatchAway away
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
        public string goals
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
        public string lineups
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
        public string substitutions
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int alternate_id_2
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool alternate_id_2Specified
        {
            get
            {
                return this.alternate_id_2FieldSpecified;
            }
            set
            {
                this.alternate_id_2FieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int venue_id
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
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool venue_idSpecified
        {
            get
            {
                return this.venue_idFieldSpecified;
            }
            set
            {
                this.venue_idFieldSpecified = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchHome : BaseTeams
    {
        private string et_scoreField;
        private string ft_scoreField;
        private int idField;
        private bool idFieldSpecified;
        private string nameField;
        private string pen_scoreField;
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchAway : BaseTeams
    {
        private string et_scoreField;
        private string ft_scoreField;
        private int idField;
        private bool idFieldSpecified;
        private string nameField;
        private string pen_scoreField;
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
        public int id
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class extended_fixturesLeagueStageMatchHalftime
    {
        private string scoreField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
