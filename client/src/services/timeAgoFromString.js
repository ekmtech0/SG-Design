// timeAgoFromString.js
export function timeAgoFromString(timeStr) {
  if (!timeStr) return "agora mesmo";

  let ms = 0;

  try {
    // se for número puro (como "1051660"), interpreta como segundos
    if (/^\d+$/.test(timeStr)) {
      ms = parseInt(timeStr, 10) * 1000;
    } else {
      let days = 0, hours = 0, minutes = 0, seconds = 0;

      // Verifica se tem dias: deve ser do tipo d.hh:mm:ss.ffffff
      const dayMatch = timeStr.match(/^(\d+)\.(\d{2}:\d{2}:\d{2}(\.\d+)?)$/);
      if (dayMatch) {
        days = parseInt(dayMatch[1], 10);
        timeStr = dayMatch[2]; // o restante é hh:mm:ss.fffffff
      }

      // Agora timeStr é hh:mm:ss.fffffff
      const timeParts = timeStr.split(':');
      if (timeParts.length !== 3) throw new Error("Formato inválido: " + timeStr);

      const [hh, mm, ss] = timeParts;
      hours = parseInt(hh, 10);
      minutes = parseInt(mm, 10);

      const [s, msStr] = ss.split('.');
      seconds = parseInt(s, 10);
      const milliseconds = Math.floor(parseFloat('0.' + (msStr || '0')) * 1000);

      ms = (((days * 24 + hours) * 60 + minutes) * 60 + seconds) * 1000 + milliseconds;
    }

    const totalSeconds = Math.floor(ms / 1000);
    if (totalSeconds < 120) return "agora mesmo";

    const totalMinutes = Math.floor(totalSeconds / 60);
    if (totalMinutes < 60) return `há ${totalMinutes} minuto${totalMinutes > 1 ? 's' : ''}`;

    const totalHours = Math.floor(totalMinutes / 60);
    if (totalHours < 24) return `há ${totalHours} hora${totalHours > 1 ? 's' : ''}`;

    const totalDays = Math.floor(totalHours / 24);
    return `há ${totalDays} dia${totalDays > 1 ? 's' : ''}`;
  } catch (err) {
    console.error("Erro ao processar timeStr:", timeStr, err);
    return "agora mesmo";
  }
}
