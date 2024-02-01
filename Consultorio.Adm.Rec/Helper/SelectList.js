export function SelectListItem(data, text) {
  return <option value={data[text[0]]}>{data[text[1]]}</option>;
}
