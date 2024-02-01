export default function Button({
  children,
  onClick,
  secundary,
  onKeyDown,
  ...res
}) {
  return (
    <button
      className={`text-white font-medium rounded-lg text-md w-full sm:w-auto px-5 py-2.5 text-center ${
        secundary == true
          ? "border-gray-600 bg-gray-600 hover:bg-gray-700"
          : "border-gray-800 bg-gray-800 hover:bg-gray-900"
      } "" ${res}`}
      onClick={onClick}
      onKeyDown={onKeyDown}
      {...res}
    >
      {children}
    </button>
  );
}
