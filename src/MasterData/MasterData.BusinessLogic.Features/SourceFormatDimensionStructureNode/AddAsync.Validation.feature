Feature: SourceFormatDimensionStructureNode Business Logic - AddAsync Input Validation

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario Outline: Exception is thrown when input is invalid

    Given there is a SourceFormatDimensionStructureNode domain object for validation
      | Field                    | Value                      |
      | Id                       | <Id>                       |
      | SourceFormatId           | <SourceFormatId>           |
      | SourceFormat             | <SourceFormat>             |
      | DimensionStructureNodeId | <DimensionStructureNodeId> |
      | DimensionStructureNode   | <DimensionStructureNode>   |
      | ResultKey                | sfdsn                      |

    When SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    Then SourceFormatDimensionStructureNode is saved operation result is an exception
      | Field | Value        |
      | Key   | sfdsn-result |

    Examples:
      | Id   | SourceFormatId | SourceFormat | DimensionStructureNodeId | DimensionStructureNode |
      | 1    | sf             | sf           | dsn                      | dsn                    |
      | none | 123            | sf           | 234                      | dsn                    |
      | none | 1              | null         | 1                        | null                   |
      | none | sf             | sf           | 123                      | dsn                    |
      | none | 123            | sf           | dsn                      | dsn                    |