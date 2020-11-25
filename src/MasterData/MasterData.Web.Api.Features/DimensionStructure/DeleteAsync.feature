Feature: DimensionStructure Endpoint - Delete method

  As a Data Owner and Data Curator
  I need to be able to delete DimensionStructures I don't need anymore
  So that, I need dimension structure delete functionality.

  Scenario: Delete DimensionStructure

    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | ds    |
      | Name     | asd   |
      | Desc     | asd   |
      | ISActive | 1     |
    And DimensionStructure is sent to the Add endpoint
      | Field     | Value     |
      | Key       | ds        |
      | ResultKey | ds-result |

    When DimensionStructure delete endpoint is called
      | Field     | Value            |
      | Key       | ds-result        |
      | ResultKey | ds-result-delete |
    And a DimensionStructure is requested
      | Field     | Value               |
      | Key       | ds-result           |
      | ResultKey | ds-result-requested |

    Then a DimensionStructure is requested result is
      | Field         | Value     |
      | Key           | ds-result |
      | ExpectedValue | null      | 