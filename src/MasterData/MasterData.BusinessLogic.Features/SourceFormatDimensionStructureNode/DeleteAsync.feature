Feature: SourceFormatDimensionStructureNode Business Logic - DeleteAsync

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario: Delete SourceFormatDimensionStructureNode

    Given there is a SourceFormatDimensionStructureNode domain object
      | Field     | Value |
      | ResultKey | sfdsn |
    And SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    When SourceFormatDimensionStructureNode is requested
      | Field     | Value                |
      | Key       | sfdsn-result         |
      | ResultKey | sfdsn-request-result |

    Then SourceFormatDimensionStructureNode is request result is empty
      | Field | Value                |
      | Key   | sfdsn-request-result |