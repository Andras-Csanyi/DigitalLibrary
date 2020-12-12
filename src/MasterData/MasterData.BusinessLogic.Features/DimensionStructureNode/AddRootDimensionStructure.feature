Feature: DimensionstructureNode Business Logic - Add Root DimensionStructureNode to SourceFormat

  As a Data Owner and Data Curator
  I need to be able to build DimensionStructureNode trees
  Which starts with adding a Root DimensionStructureNode to a SourceFormat
  So that, I need a functionality providing it.

  Scenario: Adds existing DimensionStructureNode as root DimensionStructure

    Given there is a saved SourceFormat domain object
      | Field     | Value       |
      | Name      | sf-1        |
      | Desc      | sf-1        |
      | IsActive  | 1           |
      | ResultKey | sf-1-result |

    When root DimensionStructureNode is created for given SourceFormat
      | Field     | Value                |
      | Key       | sf-1-result          |
      | ResultKey | sf-1-root-dsn-result |
    And SourceFormat is requested with DimensionStructureNode tree
      | Field     | Value              |
      | Key       | sf-1-result        |
      | ResultKey | sf--queried-result |

    Then SourceFormat has root DimensionStructureNode
      | Field           | Value       |
      | SourceFormatKey | sf-1-result |