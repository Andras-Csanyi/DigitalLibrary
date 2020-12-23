Feature: SourceFormatDimensionStructureNode Business Logic - UpdateAsync

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario: Modify a SourceFormatDimensionStructureNode when only SourceFormat exists

    Given there is a saved SourceFormat domain object
      | Field     | Value |
      | Name      | name  |
      | Desc      | desc  |
      | IsActive  | 1     |
      | ResultKey | sf-1  |
    And there is a saved SourceFormat domain object
      | Field     | Value |
      | Name      | name2 |
      | Desc      | desc2 |
      | IsActive  | 1     |
      | ResultKey | sf-2  |
    And there is a SourceFormatDimensionStructureNode domain object
      | Field           | Value |
      | ResultKey       | sfdsn |
      | SourceFormatKey | sf-1  |
    And SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |
    And SourceFormatDimensionStructureNode is modified
      | Field           | Value          |
      | Key             | sfdsn-result   |
      | SourceFormatKey | sf-2           |
      | ResultKey       | sfdsn-modified |
    And modified SourceFormatDimensionStructureNode is saved
      | Field     | Value                |
      | Key       | sfdsn-modified       |
      | ResultKey | sfdsn-modified-saved |

    Then SourceFormatDimensionStructureNode id not equals to
      | Field       | Value                |
      | Key         | sfdsn-modified-saved |
      | NotEqualsTo | 0                    |
    And SourceFormatDimensionStructureNode DimensionStructureNodeId nullable equals to
      | Field    | Value                |
      | Key      | sfdsn-modified-saved |
      | EqualsTo | null                 |
    And SourceFormatDimensionStructureNode SourceFormatId is
      | Field           | Value                |
      | Key             | sfdsn-modified-saved |
      | SourceFormatKey | sf-2                 |

  Scenario: Modify a SourceFormatDimensionStructureNode SourceFormat and DimensionStructureNode relations

    Given there is a saved SourceFormat domain object
      | Field     | Value |
      | Name      | name  |
      | Desc      | desc  |
      | IsActive  | 1     |
      | ResultKey | sf-1  |
    And there is a saved SourceFormat domain object
      | Field     | Value |
      | Name      | name2 |
      | Desc      | desc2 |
      | IsActive  | 1     |
      | ResultKey | sf-2  |
    And there is a saved DimensionStructureNode domain object
      | Field     | Value |
      | IsActive  | 1     |
      | ResultKey | dsn-1 |
    And there is a saved DimensionStructureNode domain object
      | Field     | Value |
      | IsActive  | 1     |
      | ResultKey | dsn-2 |
    And there is a SourceFormatDimensionStructureNode domain object
      | Field                     | Value |
      | ResultKey                 | sfdsn |
      | SourceFormatKey           | sf-1  |
      | DimensionStructureNodeKey | dsn-1 |
    And SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |
    And SourceFormatDimensionStructureNode is modified
      | Field                     | Value          |
      | Key                       | sfdsn-result   |
      | SourceFormatKey           | sf-2           |
      | DimensionStructureNodeKey | dsn-2          |
      | ResultKey                 | sfdsn-modified |
    And modified SourceFormatDimensionStructureNode is saved
      | Field     | Value                |
      | Key       | sfdsn-modified       |
      | ResultKey | sfdsn-modified-saved |

    Then SourceFormatDimensionStructureNode id not equals to
      | Field       | Value        |
      | Key         | sfdsn-result |
      | NotEqualsTo | 0            |
    And SourceFormatDimensionStructureNode DimensionStructureNodeId is
      | Field                     | Value                |
      | Key                       | sfdsn-modified-saved |
      | DimensionStructureNodeKey | dsn-2                |
    And SourceFormatDimensionStructureNode SourceFormatId is
      | Field           | Value                |
      | Key             | sfdsn-modified-saved |
      | SourceFormatKey | sf-2                 |