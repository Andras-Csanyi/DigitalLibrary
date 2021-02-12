Feature: DimensionStructure REST endpoint - AddAsync method

  As a Data Owner and Data Curator
  I need to be able to add new DimensionStructure via REST endpoint
  So that, I need a REST endpoint capable doing it.

  Scenario: Adds DimensionStructure

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
    When a DimensionStructure is requested
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
    And DimensionStructure IsActive property equals to
      | Field      | Value               |
      | Key        | ds-result-requested |
      | ComparedTo | ds-result           |
    And DimensionStructure Id property is not
      | Field     | Value               |
      | Key       | ds-result-requested |
      | NotEquals | 0                   |