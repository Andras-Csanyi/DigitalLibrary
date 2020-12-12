Feature: DimensionstructureNode Business Logic - Delete Root DimensionStructureNode from SourceFormat

  As a Data Owner and Data Curator
  I need to be able to manage DimensionStructureNode trees
  Which includes delete root DimensionStructureNode from a SourceFormat
  So that, I need a functionality providing it.

  Scenario: Removes DimensionStructureNode as root DimensionStructureNode

    Given there is a saved SourceFormat domain object
      | Field     | Value       |
      | Name      | sf-1        |
      | Desc      | sf-1        |
      | IsActive  | 1           |
      | ResultKey | sf-1-result |
    And root DimensionStructureNode is created for given SourceFormat
      | Field     | Value                |
      | Key       | sf-1-result          |
      | ResultKey | sf-1-root-dsn-result |

    When root DimensionStructureNode of give SourceFormat is deleted
      | Field     | Value                        |
      | Key       | sf-1-result                  |
      | ResultKey | sf-1-root-dsn-deleted-result |
    And SourceFormat is requested with DimensionStructureNode tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | sf-queried-result |

    Then SourceFormat does not have DimensionStructureNode
      | Field | Value             |
      | Key   | sf-queried-result |