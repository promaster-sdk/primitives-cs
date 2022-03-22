# primitives-cs

> NOTE: The code is provided as-is without support. Support is available by separate agreement with Divid Promaster.

C# property values, filtering, unit of measure (uom)

The the code is provided as-is without support. It is possible to get support by separate agreement with [Divid Promaster AB](https://promaster.se).

## Property values and filtering

When working with products that have many variants it is helpful to think of each variant as a combination of properties instead of an article number. In this library the properties are represented by a set of name/value pairs in the PropertyValueSet type. This set of properties can then be checked against a filter represented by the PropertyFilter type.

## Unit of measure (uom)

Extensible unit of measure conversion.

## How to contribute

Start with an issue to dicsuss. If discussions leads to code changed then create a PR. Make sure you prefix either one commit your PR title with a conventional commit prefix so that the version bump and chnagelong can be automatically generated from the PR's squashed commit. In case you have a single commit in the PR it seems it has to have the prefix in the commit message as the PR title will not be used.
