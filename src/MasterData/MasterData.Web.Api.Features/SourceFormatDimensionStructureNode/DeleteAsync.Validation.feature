Feature: SourceFormatDimensionStructureNode REST Api - Delete Method input validation

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes
  And they are available on REST endpoints

  Scenario: Exception is thrown when input is invalid

    Given there is a SourceFormatDimensionStructureNode domain object
      | Field     | Value |
      | ResultKey | sfdsn |

    When SourceFormatDimensionStructureNode is deleted
      | Field     | Value               |
      | Key       | sfdsn               |
      | ResultKey | sfdsn-delete-result |

    Then SourceFormatDimensionStructureNode delete operation result is an exception
      | Field                  | Value               |
      | Key                    | sfdsn-delete-result |
      | ExpectedHttpStatusCode | 400                 |
