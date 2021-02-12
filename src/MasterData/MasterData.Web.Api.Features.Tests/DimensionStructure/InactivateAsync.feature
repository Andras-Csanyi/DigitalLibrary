Feature: DimensionStructure Endpoint - Inactivate method

  As a Data Owner and Data Curator
  I need to be able to inactivate DimensionStructures I don't need anymore
  So that, I need dimension structure inactivate functionality.

  Scenario: Inactivate DimensionStructure

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

    When DimensionStructure inactivate endpoint is called
      | Field     | Value            |
      | Key       | ds-result        |
      | ResultKey | ds-result-delete |
    And a DimensionStructure is requested
      | Field     | Value               |
      | Key       | ds-result           |
      | ResultKey | ds-result-requested |

    Then DimensionStructure name property equals to
      | Field      | Value               |
      | Key        | ds-result-requested |
      | ComparedTo | ds-result           |
    And DimensionStructure desc property equals to
      | Field      | Value               |
      | Key        | ds-result-requested |
      | ComparedTo | ds-result           |
    And DimensionStructure Id property is
      | Field         | Value               |
      | Key           | ds-result-requested |
      | ExpectedValue | 0                   |