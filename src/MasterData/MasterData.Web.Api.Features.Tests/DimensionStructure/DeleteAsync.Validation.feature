Feature: DimensionStructure Endpoint - Delete method input validation

  As a Data Owner and Data Curator
  I need to be able to delete DimensionStructures I don't need anymore
  And I also need that this function must be validated,
  So that, I need dimension structure delete input validation functionality.

  @ignore
  Scenario: When input is invalid it returns Bad Request

    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | ds    |
      | Name     | asd   |
      | Desc     | asd   |
      | ISActive | 1     |

    When DimensionStructure delete endpoint is called
      | Field     | Value            |
      | Key       | ds               |
      | ResultKey | ds-result-delete |
    And a DimensionStructure is requested
      | Field     | Value               |
      | Key       | ds                  |
      | ResultKey | ds-result-requested |

    Then operation result is
      | Field         | Value               |
      | Key           | ds-result-requested |
      | ExpectedValue | 200                 | 