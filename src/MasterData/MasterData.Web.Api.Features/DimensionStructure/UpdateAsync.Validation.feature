Feature: DimensionStructure REST Endpoint - UpdateAsync method input validation

  As a Data Owner and Data Curator
  I need to be able to update DimensionStructures
  And the provided update data needs to be validated
  So that, I need DimensionStructure update validation.

  Scenario Outline: DimensionStructure update operation returns bad request when input is invalid

    Given there is a DimensionStructure domain object
      | Field    | Value         |
      | Key      | ds            |
      | Name     | <Name>        |
      | Desc     | <Description> |
      | ISActive | <IsActive>    |
    And stored DimensionStructure object Id property is set to
      | Field     | Value |
      | Key       | ds    |
      | IdValue   | 1     |
      | ResultKey | ds    |
    When DimensionStructure is sent to the Update endpoint
      | Field     | Value     |
      | Key       | ds        |
      | ResultKey | ds-result |
    Then operation result is
      | Field         | Value     |
      | Key           | ds-result |
      | ExpectedValue | 400       |

    Examples:
      | Name    | Description | IsActive |
      | null    | asd         | 1        |
      | empty   | asd         | 1        |
      | 3spaces | asd         | 1        |
      | as      | asd         | 1        |

      | asd     | null        | 1        |
      | asd     | empty       | 1        |
      | asd     | 3spaces     | 1        |
      | asd     | as          | 1        |

      | asd     | asd         | 2        |