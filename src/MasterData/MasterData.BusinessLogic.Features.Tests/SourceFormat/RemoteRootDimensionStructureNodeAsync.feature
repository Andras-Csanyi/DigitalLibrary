Feature: SourceFormat Business Logic - Remove Root DimensionStructureNode

  As a Data Owner and Data Curator
  I need to be able to build DimensionStructureNode trees
  Which includes being able to remove root DimensionStructureNode
  So that, I need a functionality providing it.

  Scenario: Deletes SourceFormat's DimensionStructureNode

    Given there is a saved SourceFormat domain object
      | Field     | Value       |
      | Name      | sf-1        |
      | Desc      | sf-1        |
      | IsActive  | 1           |
      | ResultKey | sf-1-result |
    And there is a saved DimensionStructureNode domain object
      | Field     | Value   |
      | IsActive  | 1       |
      | ResultKey | ds-node |
    And DimensionStructureNode is added to SourceFormat as root
      | Field                     | Value                |
      | DimensionStructureNodeKey | ds-node              |
      | SourceFormatKey           | sf-1-result          |
      | ResultKey                 | sf-1-root-dsn-result |
    And operation result is
      | Field         | Value                |
      | Key           | sf-1-root-dsn-result |
      | ExpectedValue | SUCCESS              |

    When SourceFormat root DimensionStructureNode is deleted
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | sf-removal-result |

    Then operation result is
      | Field         | Value             |
      | Key           | sf-removal-result |
      | ExpectedValue | SUCCESS           |
    And SourceFormat is requested with DimensionStructureNode tree
      | Field     | Value                       |
      | Key       | sf-1-result                 |
      | ResultKey | sf-queried-with-tree-result |
    And SourceFormat does not have root DimensionStructureNode
      | Field | Value                       |
      | Key   | sf-queried-with-tree-result |