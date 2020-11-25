Feature: DimensionStructure Endpoint - Inactivate method input validation

  As a Data Owner and Data Curator
  I need to be able to inactivate DimensionStructures I don't need anymore
  And it has to be validated whether this function can be executed
  So that, I need dimension structure inactivate functionality.

  Scenario: Inactivate method returns Bad Request

    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | ds    |
      | Name     | asd   |
      | Desc     | asd   |
      | ISActive | 1     |

    When DimensionStructure inactivate endpoint is called
      | Field     | Value            |
      | Key       | ds               |
      | ResultKey | ds-result-delete |

    Then operation result is
      | Field         | Value            |
      | Key           | ds-result-delete |
      | ExpectedValue | 400              | 