Feature: SourceFormat REST Api - Requesting all active SourceFormats

  As a Data Owner and Data Curator
  I need to be able to list SourceFormat entities in the system
  Moreover I need to be able to list only the actives
  So that, I need a functionality providing this.

  Scenario Outline: Only active SourceFormats are listed

    Given I have saved SourceFormats in the system
      | Field    | Value          |
      | Amount   | <ActiveAmount> |
      | IsActive | 1              |
    And I have saved SourceFormats in the system
      | Field    | Value            |
      | Amount   | <InactiveAmount> |
      | IsActive | 0                |
    When I request list of active SourceFormats
      | Field     | Value   |
      | ResultKey | sf-list |
    Then the length of the list is
      | Field          | Value            |
      | Key            | sf-list          |
      | ExpectedAmount | <ExpectedAmount> |

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 0              | 1              |
      | 1            | 1              | 1              |
      | 0            | 1              | 0              |
      | 5            | 0              | 5              |