Feature: SourceFormat REST Api - adding root DimensionStructureNode to SourceFormat

As a Data Owner and Data Curator
I need to be able to build SourceFormat data structure and add root DimensionStructure to it.

    Scenario: Returns Bad Request when SourceFormat already have a root DimensionStructureNode
        Given there is a saved SourceFormat domain object
          | Field     | Value     |
          | Key       | sf        |
          | ResultKey | sf-result |
        And there is a saved DimensionStructureNode domain object
          | Field     | Value           |
          | Key       | dsn-root        |
          | ResultKey | dsn-root-result |
        And root DimensionStructureNode is added to SourceFormat
          | Field                           | Value              |
          | SourceFormatResultKey           | sf-result          |
          | DimensionStructureNodeResultKey | dsn-root-result    |
          | ResultKey                       | sf-add-root-result |
        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | Key       | dsn-next-root        |
          | ResultKey | dsn-next-root-result |
        When DimensionStructureNode is added to SourceFormat as root DimensionStructureNode
          | Field                           | Value                |
          | SourceFormatResultKey           | sf-next-result       |
          | DimensionStructureNodeResultKey | dsn-next-root-result |
          | ResultKey                       | sf-add-root-result   |
        Then it returns
          | Field      | Value              |
          | ResultKey  | sf-add-root-result |
          | StatusCode | 400                |

    Scenario: Returns Ok when DimensionStructureNode is added as root to SourceFormat
