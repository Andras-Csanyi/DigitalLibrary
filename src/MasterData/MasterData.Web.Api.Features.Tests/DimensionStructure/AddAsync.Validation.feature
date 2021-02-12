Feature: DimensionStructure REST Endpoint - Add Method Input Validation

  As a Data Owner and Data Curator
  I need to be able to add DimensionStructure to the system
  And input validation is needed in order to keep the data sctructure solid
  So that, I need Add method input validation.

  Scenario Outline: When input is invalid it returns bad request Http code

    Given there is a DimensionStructure domain object
      | Field    | Value         |
      | Key      | ds            |
      | Name     | <Name>        |
      | Desc     | <Description> |
      | ISActive | <IsActive>    |
    When DimensionStructure is sent to the Add endpoint
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