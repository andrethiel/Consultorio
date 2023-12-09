import React, { useState } from "react";

// import { Container } from './styles';

function AutoComplete({ data, onChange, onSelected, placeholder }) {
  const [suggestions, setSugesstions] = useState([]);
  const [isHideSuggs, setIsHideSuggs] = useState(false);
  const [selectedVal, setSelectedVal] = useState("");

  const handler = (e) => {
    setSugesstions(data.filter((i) => i.startsWith(e.target.value)));
  };

  const handleChange = (e) => {
    const input = e.target.value;
    setIsHideSuggs(false);
    setSelectedVal(input);
    onChange(input);
  };

  const hideSuggs = (value) => {
    onSelected(value);
    setSelectedVal(value);
    setIsHideSuggs(true);
  };

  return (
    <div>
      <div className="flex">
        <input
          className="rounded-lg border undefined block flex-1 min-w-0 w-full p-2.5"
          placeholder={placeholder}
          value={selectedVal}
          onChange={handleChange}
          onKeyUp={handler}
        />
      </div>

      <div
        className="z-auto overflow-auto rounded-lg"
        style={{ display: isHideSuggs ? "none" : "block" }}
      >
        {suggestions.map((item, idx) => (
          <div
            key={"" + item + idx}
            onClick={() => {
              hideSuggs(item);
            }}
            className="hover:bg-zinc-400 rounded-lg"
          >
            {item}
          </div>
        ))}
      </div>
    </div>
  );
}

export default AutoComplete;
