Feature: SourceFormatDimensionStructureNode Business Logic - Delete

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario: Delete a SourceFormatDimensionStructureNode

    Given there is a SourceFormatDimensionStructureNode domain object
      | Field     | Value |
      | ResultKey | sfdsn |

    And SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    When SourceFormatDimensionStructureNode is deleted
      | Field     | Value               |
      | Key       | sfdsn-result        |
      | ResultKey | sfdsn-delete-result |

    Then SourceFormatDimensionStructureNode delete operation result is
      | Field         | Value               |
      | Key           | sfdsn-delete-result |
      | ExpectedValue | SUCCESS             |
    And SourceFormatDimensionStructureNode is requested
      | Field     | Value                |
      | Key       | sfdsn-result         |
      | ResultKey | sfdsn-request-result |
    And single item request result is
      | Field         | Value                |
      | Key           | sfdsn-request-result |
      | ExpectedValue | null                 |
