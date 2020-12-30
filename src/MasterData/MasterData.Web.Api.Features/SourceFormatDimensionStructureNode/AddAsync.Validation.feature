Feature: SourceFormatDimensionStructureNode REST Api - AddAsync Input Validation

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes
  And these methods should be available via REST Api

  Scenario Outline: REST endpoint returns error when input is invalid

    Given there is a SourceFormatDimensionStructureNode domain object for validation
      | Field                    | Value                      |
      | Id                       | <Id>                       |
      | SourceFormatId           | <SourceFormatId>           |
      | DimensionStructureNodeId | <DimensionStructureNodeId> |
      | ResultKey                | sfdsn                      |

    When SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    Then SourceFormatDimensionStructureNode endpoint returns an error
      | Field | Value        |
      | Key   | sfdsn-result |

    Examples:
      | Id   | SourceFormatId | DimensionStructureNodeId |
      | 1    | none           | none                     |
      | none | 0              | none                     |
      | none | none           | 0                        | 
