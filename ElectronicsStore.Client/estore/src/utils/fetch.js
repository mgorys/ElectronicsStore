export async function get(endpoint, paramsObj) {
  const url = 'https://localhost:7202/api/';
  let wholeUrl;
  if (paramsObj !== '') {
    wholeUrl = buildUrl(url, endpoint, paramsObj);
  } else {
    wholeUrl = url + endpoint;
  }
  let response = await fetch(wholeUrl, {
    headers: { 'content-type': 'application/json' },
    method: 'GET',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    console.log('error z url : ', wholeUrl);
    throw new Error(response.statusText);
  }

  let result = await response.json();
  console.log('poszlo z url', wholeUrl, result);
  return result;
}

export async function post(url, data) {
  let response = await fetch(url, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      'content-type': 'application/json',
    },
    method: 'POST',
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }

  return await response.json();
}

export function buildUrl(url, endpoint, paramsObj) {
  let wholeUrl = url + endpoint;
  if (paramsObj !== null) {
    wholeUrl = wholeUrl + '/';
    wholeUrl = wholeUrl + paramsObj;
  }
  return wholeUrl;
}

// ??

//   if (!(url.endsWith('?') || url.endsWith('&')) && paramsObj != null) {
//     wholeUrl = wholeUrl + '?';
//   }
//   if (paramsObj !== null) {
//     wholeUrl = wholeUrl + convertToURLParams(paramsObj);
//   }

//   console.log('url', wholeUrl);
//   return wholeUrl;
// }
// function convertToURLParams(object) {
//   var str = '';
//   for (var key in object) {
//     if (str !== '') {
//       str += '&';
//     }
//     str += key + '=' + encodeURIComponent(object[key]);
//   }
//   return str;
// }
